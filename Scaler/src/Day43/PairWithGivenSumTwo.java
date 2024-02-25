package Day43;

public class PairWithGivenSumTwo {

	public static void main(String[] args) {
		int ans = solve(new int[] { 1, 5, 3, 4, 2 }, 3);
		System.out.println(ans);
	}
	public static int solve(int[] A, int B) {
        int N = A.length, L = 0, R = N - 1;
        long ans = 0;
        while (L < R) {
            if ((A[L] + A[R]) == B) {
                if (A[L] == A[R]) {
                long count = (R - L + 1);
                ans += (count * (count - 1)) / 2;
                break;
                }
                long countL = 0;
                for (int i = L; i < R; i++) {
                    if (A[i] == A[L]) {
                        countL++;
                    } else {
                        break;
                    }
                }
                long countR = 0;
                for (int i = R; i > L; i--) {
                    if (A[i] == A[R]) {
                        countR++;
                    } else {
                        break;
                    }
                }
                ans += countL * countR;
                L += (int) countL;
                R -= (int) countR;
            } else if ((A[L] + A[R]) > B) {
                R--;
            } else {
                L++;
            }
        }
        return (int) ans % 1000000007;
    }
}
