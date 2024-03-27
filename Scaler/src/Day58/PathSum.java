package Day58;

public class PathSum {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}
	
	public static int hasPathSum(TreeNode A, int B) {
        return hasSum(A, B, 0);
    }
     private static int hasSum(TreeNode node, int B, int currSum){
        if(node == null){
            return 0;
        }

        currSum += node.val;
        if(node.left==null && node.right==null && currSum==B){
            return 1;
        }

        if(hasSum(node.left, B, currSum) == 1 || hasSum(node.right, B, currSum) == 1){
            return 1;
        }

        return 0;
    }

}
