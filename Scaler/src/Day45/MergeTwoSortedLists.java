package Day45;

public class MergeTwoSortedLists {

	public static void main(String[] args) {
		int[] array = new int[] { 5, 8, 20 };
		int[] array2 = new int[] { 4, 11, 15 };
		ListNode head = new ListNode(array[0]);
		ListNode head2 = new ListNode(array2[0]);
		var temp = head;
		for (int i = 1; i < array.length; i++) {
			ListNode new_node = new ListNode(array[i]);
			temp.next = new_node;
			if (i == 1) {
				head.next = temp;
			}
			temp = temp.next;
		}
		temp = head2;
		for (int i = 1; i < array2.length; i++) {
			ListNode new_node = new ListNode(array2[i]);
			temp.next = new_node;
			if (i == 1) {
				head.next = temp;
			}
			temp = temp.next;
		}
		ListNode ans = mergeTwoLists(head, head2);
		printElement(ans);
	}
	public static ListNode mergeTwoLists(ListNode A, ListNode B) {
        if(A == null){
            return B;
        }
        if(B == null){
            return A;
        }

        ListNode head;
        if(A.val <= B.val){
            head = A;
            A = A.next;
        }
        else{
            head = B;
            B = B.next;
        }
        ListNode temp = head;
        while(A!= null && B !=null){
           if(A.val <= B.val){
             temp.next = A;
             A = A.next;
           }
           else{
             temp.next = B;
             B = B.next;
           }
           temp = temp.next;
        }
        if(A==null){
            temp.next = B;
        }else{
            temp.next = A;
        }

        return head;
    }
	public static void printElement(ListNode head) {
		ListNode temp = head;
		while (temp != null) {
			System.out.print(temp.val);
			temp = temp.next;
		}
	}
}
